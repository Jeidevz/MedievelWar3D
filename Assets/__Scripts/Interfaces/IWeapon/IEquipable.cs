using UnityEngine;

public interface IEquipable {
    void equip(Transform holder, Vector3 ePosition, Vector3 eRotation);
    void unEquip();
}
