import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EventService } from 'src/app/Service/event.service';
import { EventsDto } from 'src/app/models/events-dto';
import { Router, RouterEvent } from '@angular/router';
import { LoadingController } from '@ionic/angular';
import { VolunteerService } from 'src/app/Service/volunteer.service';
import { ValunteerDto } from 'src/app/models/valunteer-dto';
import { DetailsValunteerDto } from 'src/app/models/details-valunteer-dto';
@Component({
  selector: 'app-event',
  templateUrl: './event.page.html',
  styleUrls: ['./event.page.scss'],
})
export class EventPage implements OnInit {
  @Output() event=new EventEmitter<EventsDto>();
  eventList: EventsDto[];
  loading:any;
  getDate:Date=new Date();
  volunteerDetails:DetailsValunteerDto;
 volunteer:ValunteerDto=new ValunteerDto;
 page=[
  {
  title:'main',
  url:'/event/main'
},
{
  title:'event-details',
  url:'/event/event-details'
}
];

selectedPath='';
  constructor(private router:Router,public eventsService:EventService,public loadingCtrl: LoadingController,private volunteerService:VolunteerService) {
   
    this.router.events.subscribe((event:RouterEvent)=> {
      this.selectedPath=event.url;
    })
  }


  ngOnInit() {
    // this.presentLoading();
    this.eventsService.listEvent().subscribe(res => {
      // this.loading.dismiss();
           this.eventList=res;

    }, err => {
    //  this.loading.dismiss();
      //come when not exist
    });
    this.volunteerService.getDetailsVolunteer().subscribe(res => {  
      this.volunteerDetails=res.VolunteerDetail; 
             this.volunteer=res;
    }, err => {
   
    });
  }



  openEventDetails(eve)
  {
    this.event.emit(eve);
    this.router.navigate(['/event-details']);
  }
  silentNotification()
  {
this.volunteerService.silentNotification().subscribe(res => {
      if(res==1)
      alert("ההודעות מושתקות")
}, err => {
});
  }

  // async presentLoading() {
  //   this.loading = await this.loadingCtrl.create({
  //     message: 'Hellooo',
  //   //  duration: 2000
  //   });
  //   return await this.loading.present();
// }
}
