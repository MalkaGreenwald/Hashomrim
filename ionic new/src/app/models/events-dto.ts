import { ValunteerEventDto } from './volunteer-event-dto';

export class EventsDto {
 public eventCode?:number
         public eventNameId?:number;
         public eventName:string;
        public eventDescription?:string;
        // האם צריך למחוק את המשתני משום שממלא ב unput ןה c# ממיר
        public heightPointAddress?:number;
        public widthPointAddress?:number;
        // מתמלא אוטומטי
        public startCallingDate:Date;
        public eventStatusId:number;
        public stringAddress:string;
         public ValunteerEvent?:ValunteerEventDto[];
}
