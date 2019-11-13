import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DefinationSerService {
  basicURL="http://localhost:61369/api/EventIonic/";
 
  constructor(private http:HttpClient) { }
  option(number: any) {
    return this.http.get(`${this.basicURL}option?VolunteerTz=${localStorage.getItem('tz')}&num=${number}`);
  }
}
 