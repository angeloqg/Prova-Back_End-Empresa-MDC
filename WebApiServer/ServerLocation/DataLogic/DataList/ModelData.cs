namespace DataLogic.DataList
{
    public class ModelData
    {
        public class ModelDataCity
        {
            public int idCity { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string contry { get; set; }
        }

        public class ModelDataState
        {
            public int idState { get; set; }
            public string state { get; set; }
            public string contry { get; set; }
        }

        public class ModelDataContry
        {
            public int idCountry { get; set; }
            public string contry { get; set; }
        }
    }
}
