namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using JetBrains.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private string value1 = "value 1";
        private string value2 = "value 2";
        private string value3 = "value 3";
        private string value4 = "value 4";
        private string value5 = "value 5";
        private string value6 = "value 6";
        private string value7 = "value 7";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value1
        {
            get
            {
                return this.value1;
            }

            set
            {
                if (value == this.value1)
                {
                    return;
                }

                this.value1 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value2
        {
            get
            {
                return this.value2;
            }

            set
            {
                if (value == this.value2)
                {
                    return;
                }

                this.value2 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value3
        {
            get
            {
                return this.value3;
            }

            set
            {
                if (value == this.value3)
                {
                    return;
                }

                this.value3 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value4
        {
            get
            {
                return this.value4;
            }

            set
            {
                if (value == this.value4)
                {
                    return;
                }

                this.value4 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value5
        {
            get
            {
                return this.value5;
            }

            set
            {
                if (value == this.value5)
                {
                    return;
                }

                this.value5 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value6
        {
            get
            {
                return this.value6;
            }

            set
            {
                if (value == this.value6)
                {
                    return;
                }

                this.value6 = value;
                this.OnPropertyChanged();
            }
        }

        public string Value7
        {
            get
            {
                return this.value7;
            }

            set
            {
                if (value == this.value7)
                {
                    return;
                }

                this.value7 = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
