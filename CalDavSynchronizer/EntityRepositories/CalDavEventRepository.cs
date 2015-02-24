// This file is Part of CalDavSynchronizer (https://sourceforge.net/projects/outlookcaldavsynchronizer/)
// Copyright (c) 2015 Gerhard Zehetbauer 
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CalDavSynchronizer.DataAccess;
using CalDavSynchronizer.Diagnostics;
using CalDavSynchronizer.EntityVersionManagement;
using DDay.iCal;
using DDay.iCal.Serialization;
using log4net;

namespace CalDavSynchronizer.EntityRepositories
{
  public class CalDavEventRepository : EntityRepositoryBase<IEvent, Uri, string>
  {
    private static readonly ILog s_logger = LogManager.GetLogger (MethodInfo.GetCurrentMethod().DeclaringType);

    private readonly ICalDavDataAccess _calDavDataAccess;
    private readonly IStringSerializer _calendarSerializer;

    public CalDavEventRepository (ICalDavDataAccess calDavDataAccess, IStringSerializer calendarSerializer)
    {
      _calDavDataAccess = calDavDataAccess;
      _calendarSerializer = calendarSerializer;
    }

    public override IEnumerable<EntityIdWithVersion<Uri, string>> GetEntityVersions (DateTime from, DateTime to)
    {
      using (AutomaticStopwatch.StartDebug (s_logger))
      {
        return _calDavDataAccess.GetEvents (from, to);
      }
    }

    public override IDictionary<Uri, IEvent> GetEntities (IEnumerable<Uri> sourceEntityIds)
    {
      using (AutomaticStopwatch.StartDebug (s_logger))
      {
        return _calDavDataAccess.GetEvents (sourceEntityIds).ToDictionary (kv => kv.Key, kv => DeserializeICalEvent (kv.Value));
      }
    }

    public override bool Delete (Uri entityId)
    {
      using (AutomaticStopwatch.StartDebug (s_logger))
      {
        return _calDavDataAccess.DeleteEvent (entityId);
      }
    }

    public override EntityIdWithVersion<Uri, string> Update (Uri entityId, Func<IEvent, IEvent> entityModifier)
    {
      using (AutomaticStopwatch.StartDebug (s_logger))
      {
        IEvent newEvent = new Event();
        newEvent = entityModifier (newEvent);
        return _calDavDataAccess.UpdateEvent (entityId, SerializeCalEvent (newEvent));
      }
    }

    public override EntityIdWithVersion<Uri, string> Create (Func<IEvent, IEvent> entityInitializer)
    {
      using (AutomaticStopwatch.StartDebug (s_logger))
      {
        IEvent newEvent = new Event();
        newEvent = entityInitializer (newEvent);
        return _calDavDataAccess.CreateEvent (SerializeCalEvent(newEvent));
      }
    }


    private string SerializeCalEvent (IEvent evt)
    {
      var calendar = new iCalendar();
      calendar.Events.Add (evt);
      return _calendarSerializer.SerializeToString (calendar);
    }

    private IEvent DeserializeICalEvent (string iCalData)
    {
      IEvent evt;

      using (var reader = new StringReader (iCalData))
      {
        var calendarCollection = (iCalendarCollection) _calendarSerializer.Deserialize (reader);
        evt = calendarCollection[0].Events[0];
      }
      return evt;
    }
  }
}