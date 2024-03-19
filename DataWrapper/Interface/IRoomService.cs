﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();

        Room Get(int ROOM_ID);

        Boolean IsRoomNameExists(Room objRoom);

        bool Create(Room objRoom);

        bool Update(Room objRoom);

        bool Delete(int ROOM_ID);
    }
}