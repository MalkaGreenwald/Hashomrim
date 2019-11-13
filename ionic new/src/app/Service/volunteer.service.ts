import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ValunteerDto } from '../models/valunteer-dto';
import { PersonalSituationDto } from '../models/personal-situation-dto';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class VolunteerService {
  
 
 
 Volunteer:ValunteerDto=new ValunteerDto();
 volunteerDetails:ValunteerDto=new ValunteerDto();
  basicURL="http://localhost:61369/api/VolunteerIonic/";
 
  constructor(private http: HttpClient) { }

  // login(volunteer:ValunteerDto) {
  //   this.Volunteer.tz=localStorage.getItem('tz');
 
  //   return this.http.post(`${this.basicURL}Login`,volunteer);
  // } 

   register(volunteer:ValunteerDto) {
    return this.http.post(`${this.basicURL}register`,volunteer);
  }
  listStatus():Observable<PersonalSituationDto[]> {
    return this.http.get<PersonalSituationDto[]>(`${this.basicURL}listStatus`);
  }

  silentNotification(): any {
    this.Volunteer.tz=localStorage.getItem('tz');
    return this.http.post(`${this.basicURL}silentNotification`,this.Volunteer);
  }
   getDetailsVolunteer():any {
    return this.http.get(`${this.basicURL}getDetailsVolunteer?volunteerTz=${localStorage.getItem('tz')}`);
  }
  ringNotification(): any {
    return this.http.post(`${this.basicURL}ringNotification`,this.Volunteer);
  }


  }





