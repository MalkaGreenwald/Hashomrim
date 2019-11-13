import { Injectable } from '@angular/core';
// import { HttpClient } from 'selenium-webdriver/http';
import { HttpClient } from '@angular/common/http';
import { EventsDto } from '../models/events-dto';
import { Observable } from 'rxjs';
import { VolunteerService } from './volunteer.service';
@Injectable({
  providedIn: 'root'
})
export class EventService {

 
eventDetail:EventsDto;
  basicURL="http://localhost:61369/api/EventIonic/";
 
  constructor(private http:HttpClient,private volunteerService:VolunteerService) { }
  listEvent():Observable<EventsDto[]> {
    return this.http.get<EventsDto[]>(`${this.basicURL}listEvent`);
  }
  listEvenDist(tz,lat,lng):Observable<EventsDto[]> {
    return this.http.get<EventsDto[]>(`http://localhost:61369/api/Event/eventByDistance/${tz}/${lat}/${lng}`);
  }
  takeEvent(event:EventsDto) {
    return this.http.get(`${this.basicURL}takeEvent?VolunteerTz=${localStorage.getItem('tz')}&eventCode=${event.eventCode}`);
  }
  checkEvent(event: EventsDto) {
    return this.http.get(`${this.basicURL}checkEvent?VolunteerTz=${localStorage.getItem('tz')}&eventCode=${event.eventCode}`);
  }
}



  
