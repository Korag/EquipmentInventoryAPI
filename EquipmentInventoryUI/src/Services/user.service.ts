import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User } from 'src/app/Models';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public async getUsers(): Promise<Array<User>> {
    var users = new Array<User>();

    await this.http.get<Array<User>>(`${environment.apiUrl}/User`, {})
      .pipe(map(result => {
        users = result;
      })).toPromise();

    return await users;
  }
}
