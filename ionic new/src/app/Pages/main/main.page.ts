import { Component, OnInit, EventEmitter, Output, ChangeDetectorRef } from '@angular/core';
import { MenuController, AlertController } from '@ionic/angular';
import { Router, RouterEvent } from '@angular/router';
import { EventService } from 'src/app/Service/event.service';
import { EventsDto } from 'src/app/models/events-dto';
import { LoadingController } from '@ionic/angular';
import { VolunteerService } from 'src/app/Service/volunteer.service';
import { ValunteerDto } from 'src/app/models/valunteer-dto';
import { DetailsValunteerDto } from 'src/app/models/details-valunteer-dto';
@Component({
  selector: 'app-main',
  templateUrl: './main.page.html',
  styleUrls: ['./main.page.scss'],
})
export class MainPage implements OnInit {
  @Output() event = new EventEmitter<EventsDto>();
  eventList: EventsDto[];
  loading: any;
  clickBall: boolean = true;
  getDate: Date = new Date();

  volunteerDetails: DetailsValunteerDto = new DetailsValunteerDto;
  volunteer: ValunteerDto = new ValunteerDto;
  setInt: any;

  constructor(private menuCtrl: MenuController, private cdRef:ChangeDetectorRef,
    private router: Router, public eventsService: EventService, public loadingCtrl: LoadingController, private volunteerService: VolunteerService,private alertCtrl: AlertController) {
  }
  ngOnInit() {
    setInterval(p => {
      this.getDate = new Date();
      this.cdRef.detectChanges();
    }, 1000 * 60)
    //  this.presentLoading();
    this.eventsService.listEvent().subscribe(res => {
      // this.loading.dismiss();
      this.eventList = res;

    }, err => {
      //  this.loading.dismiss();
      //come when not exist
    });
    this.volunteerService.getDetailsVolunteer().subscribe(res => {
      this.volunteerDetails = res.VolunteerDetail;
      this.volunteer = res;
    }, err => {

    });
  }
  openMenu() {
    this.menuCtrl.toggle();
  }


  openEventDetails(eve) {
    //this.event.emit(eve);
    this.eventsService.eventDetail = eve;
    this.router.navigate(['/event-details']);
  }
  silentNotification() {
    if (this.clickBall) {
      this.volunteerService.silentNotification().subscribe(async res => {
        if (res == 1) {
          this.volunteerDetails.statusValunteer="לא פעיל"
          this.set24hour();
            this.clickBall = false;
            const alert = await this.alertCtrl.create({
              // header: 'Alert',
              // subHeader: 'Subtitle',
              message: 'ההודעות מושתקות למשך 24 שעות',
              buttons: ['אישור']
            });
          
            await alert.present();

        } err=>{
          this.error();
        }

      });
    }
    else {

      this.volunteerService.ringNotification().subscribe(res => {
        if (res == 1) {
          clearInterval(this.setInt);
          this.clickBall = true;
          this.volunteerDetails.statusValunteer="פעיל"

        }

      });
    }
  }
  async error(){
    const alert = await this.alertCtrl.create({
      // header: 'Alert',
      // subHeader: 'Subtitle',
      message: 'יש לפנות למנהל המערכת',
      buttons: ['חזור']
    });
  
    await alert.present();
  }
  set24hour() {
    this.setInt = setInterval(p => {
      this.silentNotification();
    }, 1000*60)
  }


  //  async presentLoading() {
  //     this.loading = await this.loadingCtrl.create({
  //       message: 'Hellooo',
  //     //  duration: 2000
  //     });
  //     return await this.loading.present();
  // }
  funcDate (date1:Date){
    var num=0;
    num+=(new Date().getHours()-new Date(date1).getHours())*24;
    num+=(new Date().getFullYear()-new Date(date1).getFullYear())*24*365*60;
    num+=new Date().getMinutes()-new Date(date1).getMinutes();
  return num;

//     var timeDiff = Math.abs(this.getDateNow.getDate() - date1);
// return timeDiff;
    // var diff = Math.abs(date1.getTime() -this.getDateNow.getTime());
    // var diffDays = Math.ceil(diff / (1000 * 3600 * 24));
    // return diffDays;
//     var diff = this.getDateNow.valueOf() - date1.valueOf();
// var diffInHours = diff/1000/60/60;
// return diffInHours;
  }
}
