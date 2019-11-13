import { Component } from '@angular/core';
import { ValunteerDto } from 'src/app/models/valunteer-dto';
import { VolunteerService } from 'src/app/Service/volunteer.service';
import { Router } from '@angular/router';
import { LoadingController, ModalController } from '@ionic/angular';
import {RegisterPage} from '../register/register.page'
import { Keyboard } from '@ionic-native/keyboard/ngx';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  checkbox2: boolean;

 // public navCtrl: NavController,public navParams: NavParams
  constructor(public router: Router) {
    if (localStorage.getItem('tz')) {
      this.router.navigate(['/menu/main']);
    }
  }
  moveRegister() {
  this.router.navigate(['/register']);
    //this.nav.push(RegisterPage);
    //this.navCtrl.setRoot(RegisterPage);
  }

  ionViewDidLoad() {

  }


}

  