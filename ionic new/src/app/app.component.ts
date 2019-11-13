import { Component } from '@angular/core';
import { Platform, ToastController, AlertController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { LocalNotifications } from '@ionic-native/local-notifications';
import { EventService } from './Service/event.service';
import { MapsAPILoader, AgmMap } from '@agm/core';
import { element } from 'protractor';
 
declare var google: any;
 
interface Marker {
  lat: number;
  lng: number;
  label?: string;
  draggable: boolean;
}
 
interface Location {
  lat: number;
  lng: number;
  viewport?: Object;
  zoom: number;
  address_level_1?:string;
  address_level_2?: string;
  address_country?: string;
  address_zip?: string;
  address_state?: string;
  marker?: Marker;
}
 

// import { FcmService } from './shared/service/fcm.service';
// import { ToastService } from './shared/service/toast.service';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  // constructor(
  //   private platform: Platform,
  //   private splashScreen: SplashScreen,
  //   private statusBar: StatusBar
  // ) {
  //   this.initializeApp();
  // }

  // initializeApp() {
  //   this.platform.ready().then(() => {
  //     this.statusBar.styleDefault();
  //     this.splashScreen.hide();
     
  //   });
  // }
  public location:Location = {
    lat: 51.678418,
    lng: 7.809007,
    marker: {
      lat: 51.678418,
      lng: 7.809007,
      draggable: true
    },
    zoom: 5
  };
  geocoder:any;
  lng: number;
  lat: number;
  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
   // private localNotifications: LocalNotifications,
    public eventsService: EventService,
    // private fcm: FcmService,
    // private toastr: ToastService,
    //public alertController: AlertController,
    public toastController: ToastController,
    public mapsApiLoader: MapsAPILoader) {
      this.mapsApiLoader = mapsApiLoader;
      this.initializeApp();
this.mapsApiLoader.load().then(() => {
this.geocoder = new google.maps.Geocoder();

});
  }

  private async presentToast(message) {
    const toast = await this.toastController.create({
      message,
      duration: 3000
    });
    toast.present();
  }

  async addNotification(title,message) {//notification
    // const alert = await this.alertController.create({
    //   header: title,
    //   subHeader: '',
    //   message: message,
    //   buttons: ['OK']
    // });

    // await alert.present();
  //   this.localNotifications.schedule({
  //     title:title,
  //     text: message,
  //     led: 'FF0000',
  //     smallIcon: 'res://calendar',
      
   };

   notificationSetup() {

      setInterval(res=>{
       var tz=1;
             if (navigator)
       {
      //  navigator.geolocation.getCurrentPosition( pos => {
           this.lng = 12;
           this.lat =12;
           this.eventsService.listEvenDist(tz,this.lat,this.lng).subscribe(res => {
            // this.loading.dismiss();
            var i = 0;
            if(res)
            res.forEach(element => {
              i++;
              this.location.marker.lat=element.widthPointAddress;
              this.location.marker.lng=element.heightPointAddress;
              this.findAddressByCoordinates(element);
              
              // this.localNotifications.schedule({
              //   id: i,
              //   text:'אירוע חדש: '+ element['lastName']+' כתובת: '+element['stringAddress']
              // });
            });
          }, err => {
            //  this.loading.dismiss();
            //come when not exist
          });
        //  },err=>{
        //    debugger;
        //  });
       }
      
      },10000)
  }

  findAddressByCoordinates(element) {
    this.geocoder.geocode({
      'location': {
        lat: this.location.marker.lat,
        lng: this.location.marker.lng
      }
    }, (results, status) => {
      this.decomposeAddressComponents(results,element);
    })
  }

  decomposeAddressComponents(addressArray,element) {
    if (addressArray.length == 0) return false;
    let address = addressArray[0].address_components;
 
    for(let element of address) {
      if (element.length == 0 && !element['types']) continue
 
      if (element['types'].indexOf('street_number') > -1) {
        this.location.address_level_1 = element['long_name'];
        continue;
      }
      if (element['types'].indexOf('route') > -1) {
        this.location.address_level_1 += ', ' + element['long_name'];
        continue;
      }
      if (element['types'].indexOf('locality') > -1) {
        this.location.address_level_2 = element['long_name'];
        continue;
      }
      if (element['types'].indexOf('administrative_area_level_1') > -1) {
        this.location.address_state = element['long_name'];
        continue;
      }
      if (element['types'].indexOf('country') > -1) {
        this.location.address_country = element['long_name'];
        continue;
      }
      if (element['types'].indexOf('postal_code') > -1) {
        this.location.address_zip = element['long_name'];
        continue;
      }

    }
    this.addNotification(element.eventName,"כתובת: "+this.location.address_level_1);
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
      this.notificationSetup();
    });
  }
}
