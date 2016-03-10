using System;
using Caliburn.Micro;
using Fallout4Checklist.Entities;
using Fallout4Checklist.Repositories;
using System.Collections.ObjectModel;

namespace Fallout4Checklist.ViewModels
{
    public class ChecklistPickerViewModel : Screen
    {
        public ChecklistPickerViewModel()
        {
            Checklists = new ObservableCollection<Checklist>(Repository.Checklists);

            var testChecklist = new Checklist();
            testChecklist.Name = "Test Checklist";
            testChecklist.DateCreated = DateTime.Now;
            Checklists.Add(testChecklist);

            var second = new Checklist();
            second.Name = "Second Checklist";
            second.DateCreated = DateTime.Now;
            Checklists.Add(second);
        }

        public bool IsAddButtonEnabled
        {
            get { return !string.IsNullOrWhiteSpace(ChecklistName); }
        }

        public bool IsRenameButtonEnabled
        {
            get { return IsAddButtonEnabled && IsButtonEnabled; }
        }

        public bool IsButtonEnabled
        {
            get { return SelectedChecklist != null; }
        }

        public ObservableCollection<Checklist> Checklists { get; set; }
        public Checklist SelectedChecklist
        {
            get { return _selectedChecklist; }
            set
            {
                _selectedChecklist = value;
                ChecklistName = _selectedChecklist?.Name;
                NotifyOfPropertyChange(() => SelectedChecklist);
                NotifyOfPropertyChange(() => IsButtonEnabled);
                NotifyOfPropertyChange(() => IsRenameButtonEnabled);
            }
        }

        public string ChecklistName
        {
            get { return _checklistName; }
            set
            {
                _checklistName = value;
                NotifyOfPropertyChange(() => ChecklistName);
                NotifyOfPropertyChange(() => IsAddButtonEnabled);
                NotifyOfPropertyChange(() => IsRenameButtonEnabled);
            }
        }

        private Checklist _selectedChecklist;
        private string _checklistName;

        public void Add()
        {
            var checklist = new Checklist();
            checklist.Name = ChecklistName;
            checklist.DateCreated = DateTime.Now;
            Checklists.Add(checklist);
            // Added all collectables to checklist
            // Save checklist to database along with collectables
            // After creation, hide checklist selection screen and show actual checklist and map.
        }

        public void Load(Checklist checklist)
        {
            // Allow switching if a previous checklist isn't loaded
            // Load up new data
            ChecklistRepository.CurrentChecklist = checklist;
        }

        public void Delete()
        {
            SelectedChecklist.IsDeleted = true;
            SelectedChecklist.DateDeleted = DateTime.Now;
            Checklists.Remove(SelectedChecklist);
            SelectedChecklist = null;
            // Save changes to database
            // Don't allow switching from this screen until another checklist is selected
        }

        public void Rename()
        {
            SelectedChecklist.Name = ChecklistName;
        }
    }
}
