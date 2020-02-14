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

}
