import { Component, OnInit } from '@angular/core';
import { FreindlyEventDto } from 'src/app/models/freindly-event-dto';
import { FreindlyMeetingSerService } from 'src/app/Service/freindly-meeting-ser.service';


@Component({
  selector: 'app-freindly-meeting',
  templateUrl: './freindly-meeting.page.html',
  styleUrls: ['./freindly-meeting.page.scss'],
})
export class FreindlyMeetingPage implements OnInit {
 friendlyMeetingList:FreindlyEventDto[];
  
 
  constructor(private freindlySer:FreindlyMeetingSerService) { }

  ngOnInit() {
    this.freindlySer.getListFmeeting().subscribe(res => {

           this.friendlyMeetingList=res;

    }, err => {
    //  this.loading.dismiss();
      //come when not exist
    });
  }
  okIcaming(friendMeeting:FreindlyEventDto)
  {
    this.freindlySer.takeFMeeting(friendMeeting).subscribe(res => {
      if (res==1)
      {
        //לרענן את הדף
      }
 
    }, err => {
      //come when not exist
    });
  }
}
