﻿using GeekDesk.Constant;
using GeekDesk.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace GeekDesk.ViewModel
{

    [Serializable]
    public class MenuInfo : INotifyPropertyChanged
    {


        private string menuName;
        private string menuId;
        private Visibility menuEdit = Visibility.Collapsed;
        private Visibility notMenuEdit = Visibility.Visible;
        private bool isEdit = false;
        private string menuGeometry;  //菜单几何图标
        private string geometryColor; //几何图标颜色
        private ObservableCollection<IconInfo> iconList = new ObservableCollection<IconInfo>();

        [field: NonSerializedAttribute()]
        private string[] NO_WRITE_ARR = new string[] { "IsEdit" };


        public bool IsEdit
        {
            get
            {
                return isEdit;
            }
            set
            {
                isEdit = value;
                OnPropertyChanged("IsEdit");
            }
        }
        public string MenuGeometry
        {
            get
            {
                if (menuGeometry == null)
                {
                    return Constants.DEFAULT_MENU_GEOMETRY;
                }
                return menuGeometry;
            }
            set
            {
                menuGeometry = value;
                OnPropertyChanged("MenuGeometry");
            }
        }

        public string GeometryColor
        {
            get
            {
                if (geometryColor == null)
                {
                    return Constants.DEFAULT_MENU_GEOMETRY_COLOR;
                }
                return geometryColor;
            }
            set
            {
                geometryColor = value;
                OnPropertyChanged("GeometryColor");
            }
        }

        public string MenuName
        {
            get
            {
                return menuName;
            }
            set
            {
                menuName = value;
                OnPropertyChanged("MenuName");
            }
        }

        public string MenuId
        {
            get
            {
                return menuId;
            }
            set
            {
                menuId = value;
                OnPropertyChanged("MenuId");
            }
        }

        public Visibility MenuEdit
        {
            get
            {
                return menuEdit;
            }
            set
            {
                menuEdit = value;
                if (menuEdit == Visibility.Visible)
                {
                    IsEdit = true;
                    NotMenuEdit = Visibility.Collapsed;
                }
                else
                {
                    IsEdit = false;
                    NotMenuEdit = Visibility.Visible;
                }
                OnPropertyChanged("MenuEdit");
            }
        }

        public Visibility NotMenuEdit
        {
            get
            {
                return notMenuEdit;
            }
            set
            {
                notMenuEdit = value;
                OnPropertyChanged("NotMenuEdit");
            }
        }

        public ObservableCollection<IconInfo> IconList
        {
            get
            {
                return iconList;
            }
            set
            {
                iconList = value;
                OnPropertyChanged("IconList");
            }
        }

        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            foreach (var field in NO_WRITE_ARR)
            {
                if (field.Equals(propertyName))
                {
                    return;
                }
            }
            CommonCode.SaveAppData(MainWindow.appData);
        }
    }
}