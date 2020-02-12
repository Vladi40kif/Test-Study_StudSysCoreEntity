import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  	responce: any;

  	constructor(private http: HttpClient) {
    	this.http.get("https://localhost:44382/weatherforecast")
    		.subscribe(respounse => {
    			this.responce = respounse;
    			console.log(this.responce);
    		})
  	};


  	do():string {
  		var data: string;

  		// var i: number = 0;
  		// while(this.responce[i]!=null){
  		// 	data+= "date" + this.responce[i].date + "<br />";
  		// 	data+= "temperatureC" + this.responce[i].temperatureC + "<br />";
  		// 	data+= "summary" + this.responce[i].summary + "<br />";
  		// 	data+= "<hr />";
  		// }
  		return data;
  	};

}
