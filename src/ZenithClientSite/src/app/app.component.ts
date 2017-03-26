import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    private title = 'ZenithClientSite Application Works!';
    private token;

    constructor(private http: Http) { }

    //Gets the users token authentification
    getToken(): string {
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        //Login information
        let data = 'grant_type=password' + '&username=a@a.a' + '&password=P@$$w0rd';

        //Http Post Request
        this.http.post(
            //Put API link here:
            "http://localhost:30228/connect/token",
            data,
            { headers: headers }
        ).map(res => res.json()).subscribe(data => { this.token = data.access_token });
        //.map(res => res.json()).subscribe(data => {console.log(data.access_token)})

        //console.log(token)
        return;
    }

    printToken(): void {
        console.log(this.token);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }
}
