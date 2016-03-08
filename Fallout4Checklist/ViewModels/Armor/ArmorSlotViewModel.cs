using Caliburn.Micro;
using Fallout4Checklist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Fallout4Checklist.ViewModels
{
    public class ArmorSlotViewModel : PropertyChangedBase
    {
        public ArmorSlotViewModel(List<ArmorSlot> slots)
        {
            foreach (var slot in slots)
                SetImageVisibility(slot);
        }

        public bool IsBodyVisible { get; set; }
        public bool IsChestVisible { get; set; }
        public bool IsEyeVisible { get; set; }
        public bool IsMouthVisible { get; set; }
        public bool IsHatVisible { get; set; }
        public bool IsLeftArmVisible { get; set; }
        public bool IsRightArmVisible { get; set; }
        public bool IsLeftLegVisible { get; set; }
        public bool IsRightLegVisible { get; set; }

        private void SetImageVisibility(ArmorSlot slot)
        {
            switch (slot.ID)
            {
                case "Body":
                    IsBodyVisible = true;
                    break;
                case "Chest":
                    IsChestVisible = true;
                    break;
                case "Mouth":
                    IsMouthVisible = true;
                    break;
                case "Eye":
                    IsEyeVisible = true;
                    break;
                case "Hat":
                    IsHatVisible = true;
                    break;
                case "Left Arm":
                    IsLeftArmVisible = true;
                    break;
                case "Right Arm":
                    IsRightArmVisible = true;
                    break;
                case "Left Leg":
                    IsLeftLegVisible = true;
                    break;
                case "Right Leg":
                    IsRightLegVisible = true;
                    break;
            }
        }
    }
}
