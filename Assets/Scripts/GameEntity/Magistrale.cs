using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TowerBattle.Renderer;

namespace TowerBattle
{
    [RequireComponent(typeof(LineRenderer))]
    public class Magistrale : MonoBehaviour
    {
        private IRenderer _renderer;

        private Tower _firstTower;
        private Tower _secondTower;

        [SerializeField] private List<Transform> _points;

        [SerializeField] private List<(Transport, float)> _toTowerSecond = new List<(Transport, float)>();
        [SerializeField] private List<(Transport, float)> _toTowerFirst = new List<(Transport, float)>();

        [SerializeField] private float _speed = 1f / 20f;

        private Curve _curve;

        private void Awake()
        {
            _firstTower = _points[0].transform.GetComponent<Tower>();
            _secondTower = _points[_points.Count - 1].transform.GetComponent<Tower>();
            _curve = new Curve(_points.Select(x => x.position).ToArray());
            _renderer = new PathRenderer(GetComponent<LineRenderer>(), _curve);
            _renderer.Select();
        }

        private void Update()
        {
            MoveUnits(Time.deltaTime * _speed, _toTowerSecond);
            MoveUnits(-Time.deltaTime * _speed, _toTowerFirst);
        }

        private void MoveUnits(float speed, List<(Transport, float)> units)
        {
            for(var i = units.Count - 1; i >= 0; i--)
            {
                (Transport, float) unit = units[i];
                unit.Item2 += speed;
                unit.Item1.transform.position = _curve.GetPoint(unit.Item2);
                units[i] = unit;

                if (unit.Item2 < 0 || unit.Item2 > 1)
                {
                    units.RemoveAt(i);
                    Destroy(unit.Item1.gameObject);
                }
            }
        }

        public bool TryGetNeigbourTower(Tower mainTower, out Tower neigbourTower)
        {
            bool result;

            if(_firstTower == mainTower)
            {
                neigbourTower = _secondTower;
                result = true;
            }
            else if(_secondTower == mainTower)
            {
                neigbourTower = _firstTower;
                result = true;
            }
            else
            {
                neigbourTower = null;
                result = false;
            }

            return result;
        }

        public void AcceptGroup(Tower tower, UnitGroup group) //TODO
        {
            var transport = Instantiate(General.Instance.GameResources.TransportPrefab);
            transport.group = group;

            if (tower == _firstTower)
            {
                _toTowerSecond.Add((transport, 0));
            }
            else
            {
                _toTowerFirst.Add((transport, 1));
            }    
        }

        #region Gizmos
        private void OnDrawGizmos()
        {
            _curve = new Curve(_points.Select(x => x.position).ToArray());
            for (var i = 0f; i < 1f; i += 0.01f)
                Gizmos.DrawLine(_curve.GetPoint(i), _curve.GetPoint(i += 0.01f));
        }

        private void OnDrawGizmosSelected()
        {
            _points.ForEach(x => Gizmos.DrawSphere(x.position, 0.5f));
        }
        #endregion
    }
}