using RegnalUDB.Models;
using System.Collections.Generic;


namespace RegnalUDB
{
    static class FactoryOperation<T>
    {
        public static Operation<T> getSuccessOperation()
        {
            return new Operation<T>();
        }

       public  static Operation<T> getFailOperation(string error)
        {
            Operation<T> operation = new Operation<T>();
            operation.Error = error;
            operation.State = false;
            return operation;
        }

        public static Operation<T> getDataOperation(List<T> data)
        {
            Operation<T> operation = new Operation<T>
            {
                Data = data
            };
            return operation;
        }

        public static Operation<T> getSingleValueOperation(object value)
        {
            Operation<T> operation = new Operation<T>
            {
                Value = value
            };
            return operation;
        }
    }
}
