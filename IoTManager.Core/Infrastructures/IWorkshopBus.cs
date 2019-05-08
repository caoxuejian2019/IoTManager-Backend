using System;
using System.Collections.Generic;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IWorkshopBus
    {
        List<WorkshopSerializer> GetAllWorkshops();
        WorkshopSerializer GetWorkshopById(int id);
        String CreateNewWorkshop(WorkshopSerializer workshopSerializer);
        String UpdateWorkshop(int id, WorkshopSerializer workshopSerializer);
        String DeleteWorkshop(int id);
    }
}