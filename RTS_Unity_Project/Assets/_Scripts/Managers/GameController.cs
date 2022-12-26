using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    [SerializeField] private Faction _playerFaction;
    private List<UnitBase> _selectedUnits;
    [SerializeField] private Transform _selectionAreaTransform;

    private void Awake() {
        _selectedUnits = new List<UnitBase>();
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    void Update() {
        SelectUnits();
    }

    private void SelectUnits() {
        if (Input.GetMouseButtonDown(0)) {
            _startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPosition.z = 0f;
            
            _selectionAreaTransform.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0)) {
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ArrangeSelectionArea(currentMousePosition);
        }

        if (Input.GetMouseButtonUp(0)) {
            _selectionAreaTransform.gameObject.SetActive(false);
            _endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _endPosition.z = 0f;
            Collider2D[] colliders = Physics2D.OverlapAreaAll(_startPosition, _endPosition);

            foreach (UnitBase unit in _selectedUnits) {
                unit.SetSelectedVisibility(false);
            }
            _selectedUnits.Clear();

            foreach (Collider2D collider in colliders) {
                UnitBase unitBase = collider.GetComponent<UnitBase>();
                if (unitBase != null && unitBase.Faction == _playerFaction) {
                    _selectedUnits.Add(unitBase);
                    unitBase.SetSelectedVisibility(true);
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            Vector3 moveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MoveSelectedUnits(moveTarget);
        }

    }

    private void ArrangeSelectionArea(Vector3 currentMousePosition) {
        currentMousePosition.z = 0f;
        Vector3 lowerLeft = new Vector3(Mathf.Min(_startPosition.x, currentMousePosition.x), Mathf.Min(_startPosition.y, currentMousePosition.y));
        Vector3 upperRight = new Vector3(Mathf.Max(_startPosition.x, currentMousePosition.x), Mathf.Max(_startPosition.y, currentMousePosition.y));
        _selectionAreaTransform.position = lowerLeft;
        _selectionAreaTransform.localScale = upperRight - lowerLeft;
    }

    private void MoveSelectedUnits(Vector3 target) {
        if (_selectedUnits.Count < 1) {
            return;
        }
        float width = _selectedUnits[0].GetStats().Width;
        float length = _selectedUnits[0].GetStats().Length; //may be changed to max from all units
        List<Vector3> positions = MovePositions.GetPositionsArundTarget(target, _selectedUnits.Count, width, length);
        int i = 0;
        foreach (UnitBase unit in _selectedUnits) {
            unit.MoveTo(positions[i++]);
        }
    }

}
