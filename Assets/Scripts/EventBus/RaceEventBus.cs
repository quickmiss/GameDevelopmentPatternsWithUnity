using UnityEngine.Events;
using System.Collections.Generic;

namespace Chapter.EventBus
{
    public class RaceEventBus
    {
        private static readonly IDictionary<RaceEventType, UnityEvent>
        Events = new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            // out은 ref와 달리 변수 초기화 없이 참조형으로 전달 가능 단, 해당 함수 내에서는 out 키워드로 넘긴 변수에 대해 무조건 값을 할당해야함.
            if(Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(RaceEventType type, UnityAction listener)
        {
            UnityEvent thisEvent;

            if(Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType type)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }

}
