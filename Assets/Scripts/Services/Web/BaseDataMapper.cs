using System;

namespace Services.Web
{
    public abstract class BaseDataMapper<TDto, TData>
    {
        public abstract TData Map(TDto dto);

        public TData[] Map(TDto[] dto)
        {
            if (dto == null)
            {
                return Array.Empty<TData>();
            }

            TData[] dataArray = new TData[dto.Length];
            for (int i = 0; i < dto.Length; i++)
                dataArray[i] = Map(dto[i]);

            return dataArray;
        }
    }
}