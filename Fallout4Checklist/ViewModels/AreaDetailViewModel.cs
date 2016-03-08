using Caliburn.Micro;
using Fallout4Checklist.Entities;
using Fallout4Checklist.Events;
using Fallout4Checklist.Repositories;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fallout4Checklist.ViewModels
{
    public class AreaDetailViewModel : Screen, IHandle<LocationBorderClick>, IHandle<MenuItemClicked>
    {
        private IEventAggregator _eventAggregator = CaliburnBootstrapper.EventAggregator;

        public AreaDetailViewModel()
        {
            _eventAggregator.Subscribe(this);
            CurrentAreaWeapons = new ObservableCollection<WeaponDetailViewModel>();
            CurrentAreaMagazines = new ObservableCollection<MagazineDetailViewModel>();
            CurrentAreaArmor = new ObservableCollection<ArmorDetailViewModel>();
            CurrentAreaQuests = new ObservableCollection<QuestListItemViewModel>();
            DisplayName = "Area Details";
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public ImagePath ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                NotifyOfPropertyChange(() => ImagePath);
            }
        }

        public string RecommendedLevel
        {
            get { return _recommendedLevel; }
            set
            {
                _recommendedLevel = value;
                NotifyOfPropertyChange(() => RecommendedLevel);
            }
        }

        public int AreaID
        {
            get { return _areaID; }
            set
            {
                _areaID = value;
                NotifyOfPropertyChange(() => AreaID);
            }
        }

        public CompanionDetailViewModel CurrentAreaCompanion
        {
            get { return _currentAreaCompanion; }
            set
            {
                _currentAreaCompanion = value;
                NotifyOfPropertyChange(() => CurrentAreaCompanion);
            }
        }

        public BobbleheadDetailViewModel CurrentAreaBobblehead
        {
            get { return _currentAreaBobblehead; }
            set
            {
                _currentAreaBobblehead = value;
                NotifyOfPropertyChange(() => CurrentAreaBobblehead);
            }
        }

        public bool HasRecommendedLevel
        {
            get { return _hasRecommendedLevel; }
            set
            {
                _hasRecommendedLevel = value;
                NotifyOfPropertyChange(() => HasRecommendedLevel);
            }
        }

        public bool HasCompanion
        {
            get { return _hasCompanion; }
            set
            {
                _hasCompanion = value;
                NotifyOfPropertyChange(() => HasCompanion);
            }
        }

        public bool HasWeapon
        {
            get { return _hasWeapon; }
            set
            {
                _hasWeapon = value;
                NotifyOfPropertyChange(() => HasWeapon);
            }
        }

        public bool HasBobblehead
        {
            get { return _hasBobblehead; }
            set
            {
                _hasBobblehead = value;
                NotifyOfPropertyChange(() => HasBobblehead);
            }
        }

        public bool HasMagazine
        {
            get { return _hasMagazine; }
            set
            {
                _hasMagazine = value;
                NotifyOfPropertyChange(() => HasMagazine);
            }
        }

        public bool HasArmor
        {
            get { return _hasArmor; }
            set
            {
                _hasArmor = value;
                NotifyOfPropertyChange(() => HasArmor);
            }
        }

        public bool HasQuests
        {
            get { return _hasQuests; }
            set
            {
                _hasQuests = value;
                NotifyOfPropertyChange(() => HasQuests);
            }
        }

        public ObservableCollection<QuestListItemViewModel> CurrentAreaQuests { get; set; }
        public ObservableCollection<WeaponDetailViewModel> CurrentAreaWeapons { get; set; }
        public ObservableCollection<MagazineDetailViewModel> CurrentAreaMagazines { get; set; }
        public ObservableCollection<ArmorDetailViewModel> CurrentAreaArmor { get; set; }

        private int _areaID;
        private string _name;
        private string _description;
        private string _recommendedLevel;
        private ImagePath _imagePath;
        private CompanionDetailViewModel _currentAreaCompanion;
        private BobbleheadDetailViewModel _currentAreaBobblehead;
        private bool _hasRecommendedLevel;
        private bool _hasCompanion;
        private bool _hasWeapon;
        private bool _hasBobblehead;
        private bool _hasMagazine;
        private bool _hasArmor;
        private bool _hasQuests;

        public void Handle(MenuItemClicked message) => UpdateDetails(message.AreaID);
        public void Handle(LocationBorderClick message) => UpdateDetails(message.AreaID);

        private void UpdateDetails(int areaID)
        {
            var area = Repository.Areas.FirstOrDefault(x => x.ID == areaID);
            DisplayName = area.Name;
            Name = area.Name;
            AreaID = area.ID;
            RecommendedLevel = area.RecommendedLevel;
            HasRecommendedLevel = area.HasRecommendedLevel;
            SetWeaponDetailViewModels(area);
            SetCompanionDetailViewModel(area);
            SetBobbleheadDetailViewModel(area);
            SetMagazineDetailViewModels(area);
            SetArmorDetailViewModel(area);
            SetRelatedQuests(area);
            HasArmor = CurrentAreaArmor.Count > 0;
            HasBobblehead = area.HasBobblehead;
            HasMagazine = area.HasMagazine;
            HasCompanion = area.HasCompanion;
            HasWeapon = CurrentAreaWeapons.Count > 0;
            HasQuests = CurrentAreaQuests.Count > 0;
        }

        private void SetRelatedQuests(Area area)
        {
            CurrentAreaQuests.Clear();
            foreach (var quest in area.Quests)
                CurrentAreaQuests.Add(new QuestListItemViewModel(quest));
        }

        private void SetArmorDetailViewModel(Area area)
        {
            CurrentAreaArmor.Clear();
            area.AllArmor.ForEach(x => CurrentAreaArmor.Add(new ArmorDetailViewModel(x)));
        }

        private void SetCompanionDetailViewModel(Area area)
        {
            var companion = area.Companions.FirstOrDefault();
            if (companion == null) return;

            CurrentAreaCompanion = new CompanionDetailViewModel(companion);
        }

        private void SetWeaponDetailViewModels(Area area)
        {
            CurrentAreaWeapons.Clear();
            area.AllWeapons.ForEach(x => CurrentAreaWeapons.Add(new WeaponDetailViewModel(x)));
        }

        private void SetBobbleheadDetailViewModel(Area area)
        {
            var bobblehead = area.Bobbleheads.FirstOrDefault();
            if (bobblehead == null) return;
            CurrentAreaBobblehead = new BobbleheadDetailViewModel(bobblehead);
        }

        private void SetMagazineDetailViewModels(Area area)
        {
            CurrentAreaMagazines.Clear();
            foreach (var item in area.Magazines)
                CurrentAreaMagazines.Add(new MagazineDetailViewModel(item));
        }
    }
}