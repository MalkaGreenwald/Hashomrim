import { Component, OnInit, Input } from '@angular/core';
import { EventsDto } from 'src/app/models/events-dto';
import { AlertController, MenuController } from '@ionic/angular';
import { EventService } from 'src/app/Service/event.service';
import { LaunchNavigator, LaunchNavigatorOptions } from '@ionic-native/launch-navigator/ngx';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.page.html',
  styleUrls: ['./event-details.page.scss'],
})
export class EventDetailsPage implements OnInit {
  event:EventsDto
  start: string;
  destination: string;
  succ: number=0;
  url: string;
  constructor(
    private launchNavigator: LaunchNavigator,private menuCtrl:MenuController,public alertController: AlertController,private eventService:EventService,private alertCtrl: AlertController) {    
    this.event=new EventsDto;
     
 
   }
   funcDate (date1:Date){
    var num=0;
    num+=(new Date().getHours()-new Date(date1).getHours())*24;
    num+=(new Date().getFullYear()-new Date(date1).getFullYear())*24*365*60;
    num+=new Date().getMinutes()-new Date(date1).getMinutes();
  return num;
   }
  ngOnInit() {
   this.event= this.eventService.eventDetail;
   this.url="https://www.waze.com/ul?ll="+this.event.widthPointAddress+"%2C-"+this.event.heightPointAddress+"&navigate=yes&zoom=17";
   this.start = "";
   this.destination = "להכניס משתנה כתובת";
   this.eventService.checkEvent(this.event).subscribe(res=>{
    if (res==1)
    this.succ= 1;
    else
    this.succ= 0;
        },err =>{
    this.error();
        });
  }
  
  openModal(){
    this.presentAlertMultipleButtons();
  }
  async presentAlertMultipleButtons() {
    const alert = await this.alertController.create({
      header: 'קבל את האירוע',
      // subHeader: 'Subtitle',
      message: 'אני רוצה לטפל באירוע',
   
      buttons: [
        {
          text: 'חזור',
          role: 'cancel',
          handler: () => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'אישור קבלת אירוע',
          handler: () => {
           this.takeEvent();
          }
        }
      ]
    });

    await alert.present();
  }
  takeEvent()
  {
  this.eventService.takeEvent(this.event).subscribe(res => {
 if (res==1)
 this.succ=1;
 else
 this.error();
},  err => {
  this.error();
});
  }
  checkEvent(){
 
  }

  async error(){
    const alert = await this.alertCtrl.create({
      // header: 'Alert',
      // subHeader: 'Subtitle',
      message: 'יש לפנות למנהל העמרכת',
      buttons: ['חזור']
    });
  
    await alert.present();
  }
  openWaze()
  {
    let options: LaunchNavigatorOptions = {
      start: this.start
  };

  this.launchNavigator.navigate(this.destination, options)
      .then(
          success => alert('Launched navigator'),
          error => alert('Error launching navigator: ' + error)
      );
    alert("wazeeeeeee")
 
  }

  

  openMenu(){
    this.menuCtrl.toggle();
  }
  
 

}
