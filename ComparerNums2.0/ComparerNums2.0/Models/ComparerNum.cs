using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ComparerNums2._0.Models
{
    class ComparerNum: INotifyPropertyChanged
    {
        private double firstnum;
        private double secondnum;
        private bool compare;
        [JsonProperty(PropertyName = "getFirstNum")]
        public double GetFirstNum
        {
            get { return firstnum; }
            set 
            {
                if (firstnum == value)
                    return;
                firstnum = value;
                OnPropertyChanged("GetFirstNum");
            }
        }
        [JsonProperty(PropertyName = "getSecondNum")]
        public double GetSecondNum
        {
            get { return secondnum; }
            set
            {
                if (secondnum == value)
                    return;
                secondnum = value;
                OnPropertyChanged("GetSecondNum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));   
        }
        [JsonProperty(PropertyName = "compareNum")]
        public bool CompareNum
        {
            get 
            {
                bool compare = firstnum == secondnum;
                return compare;
            }
            set
            {
                if (compare == value)
                    return;
                compare = value;
                OnPropertyChanged("CompareNum");
            }
            
        }
    }
}
