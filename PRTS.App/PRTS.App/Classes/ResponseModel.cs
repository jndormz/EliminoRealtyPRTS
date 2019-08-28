namespace PRTS.App.Classes {
    using System.Collections.Generic;
    public class ResponseModel<T> {
        public ResponseModel() {
            Message = new List<string>();
        }

        public bool Succeed { get; set; }

        public T Data { get; set; }

        public List<string> Message { get; set; }
    }
}
