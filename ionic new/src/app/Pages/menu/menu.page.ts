import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';
import { EventsDto } from 'src/app/models/events-dto';
import { VolunteerService } from 'src/app/Service/volunteer.service';
import { ValunteerDto } from 'src/app/models/valunteer-dto';
import { DetailsValunteerDto } from 'src/app/models/details-valunteer-dto';
import { Platform } from '@ionic/angular';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
})
export class MenuPage implements OnInit {
 
  eventList: EventsDto[];
  loading:any;
  getDate:Date=new Date();
  volunteerDetails:DetailsValunteerDto;
 volunteer:ValunteerDto=new ValunteerDto;
  page=[
    {
    title:'מסך-ראשי',
    url:'/menu/main'
  },
  {
    title:'הגדרות',
    url:'/menu/definition'
  },{
    title:'מפגש חברתי',
    url:'/menu/freindly-meeting'
  },
  ];
  pp={
    title:'בקרו בי',
    url:'https://ionicframework.com/docs/appflow/devapp'
  }
  selectedPath='';

  // toggleRightMenu() {
  //   this.menuCtrl.toggle('right');
  // }
  constructor(private router:Router,private volunteerService:VolunteerService) {

    this.router.events.subscribe((event:RouterEvent)=> {
      this.selectedPath=event.url;
    });

    this.volunteerService.getDetailsVolunteer().subscribe(res => {  
      this.volunteerDetails=res.VolunteerDetail; 
             this.volunteer=res;
    }, err => {
   
    });
  }


  ngOnInit() {  
  
  }
}
