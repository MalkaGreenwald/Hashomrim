import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EventsDto } from '../models/events-dto';
import { HttpClient } from '@angular/common/http';
import { FreindlyEventDto } from '../models/freindly-event-dto';
import { VolunteerService } from './volunteer.service';

@Injectable({
  providedIn: 'root'
})
export class FreindlyMeetingSerService {

 
  basicURL="http://localhost:61369/api/FreindlyMeetingIonic/";
  constructor(private  http:HttpClient,private volunteerService:VolunteerService) { }



  getListFmeeting():Observable<FreindlyEventDto[]> {
    return this.http.get<FreindlyEventDto[]>(`${this.basicURL}getListFmeeting`);
  }

  

  takeFMeeting(friendMeeting: FreindlyEventDto){
    return this.http.get(`${this.basicURL}takeFMeeting?VolunteerTz=${localStorage.getItem('tz')}&friendMeetingCode=${friendMeeting.freindlyCode}`);
  }
}
