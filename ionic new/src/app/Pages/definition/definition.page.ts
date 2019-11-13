import { Component, OnInit } from '@angular/core';
import { DefinationSerService } from 'src/app/Service/defination-ser.service';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-definition',
  templateUrl: './definition.page.html',
  styleUrls: ['./definition.page.scss'],
})
export class DefinitionPage implements OnInit {

  constructor(private defSev:DefinationSerService,private alertCtrl: AlertController) { }

  ngOnInit() {
  }
option(num){
this.defSev.option(num).subscribe(async res => {
  if (res==1)
  {
    const alert = await this.alertCtrl.create({
      // header: 'Alert',
      // subHeader: 'Subtitle',
      message: 'בחירתך נקלטה בהצלחה',
      buttons: ['אישור']
    });
  
    await alert.present();

}err=>{
  this.error();
}

});
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
}

