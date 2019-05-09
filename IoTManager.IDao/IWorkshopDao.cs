using System;
using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IWorkshopDao
    {
        List<WorkshopModel> Get();
        WorkshopModel GetById(int id);
        String Create(WorkshopModel workshopModel);
        String Update(int id, WorkshopModel workshopModel);
        String Delete(int id);
    }
}