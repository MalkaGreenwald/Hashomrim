import { Component, OnInit } from '@angular/core';
import { ValunteerDto } from '../../models/valunteer-dto';
import { PersonalSituationDto } from '../../models/personal-situation-dto';
import { VolunteerService } from '../../Service/volunteer.service';
import { AlertController } from '@ionic/angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {
  
  succ:number=0; 
  volunteer:ValunteerDto;
   
  
   listStatus:PersonalSituationDto[];
  constructor(public router:Router, public valunteerSer:VolunteerService ,private alertCtrl: AlertController) {  
  this.volunteer= new ValunteerDto();
  //  this.ionViewDidLoad();
  }

  ngOnInit() {
    this.valunteerSer.listStatus().subscribe(res => {
      this.listStatus=res;
    }, err => {
      //come when not exist
    });
  
  }
  
  register()
{
  debugger;
this.valunteerSer.register(this.volunteer).subscribe(async res => {
  if(res==1)
  {
    this.succ=1;
    localStorage.setItem('tz',this.volunteer.tz);
    this.router.navigate(['/menu/main']);
  }
  else if(res==5)
{
  const alert = await this.alertCtrl.create({
    // header: 'Alert',
    // subHeader: 'Subtitle',
    message: 'הינך רשום במערכת, פנה למנהל',
    buttons: ['חזור']
  });

  await alert.present();
}
else
{
  const alert = await this.alertCtrl.create({
    // header: 'Alert',
    // subHeader: 'Subtitle',
    message: 'ישנה בעיה בנתונים יש לפנות למנהל העמרכת',
    buttons: ['חזור']
  });

  await alert.present();
}

}, async err => {
  const alert = await this.alertCtrl.create({
    // header: 'Alert',
    // subHeader: 'Subtitle',
    message: 'יש לפנות למנהל העמרכת',
    buttons: ['חזור']
  });

  await alert.present();
});
//this.getPhoneFromSim();
}
}
