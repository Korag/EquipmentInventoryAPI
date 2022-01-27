import { Injectable } from '@angular/core';
import { AddUserAssetOwnership, UserAssetOwnership } from 'src/app/Models';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserAssetService {

  constructor(private http: HttpClient) { }

  public async createUserAssetOwnership(userAsset: AddUserAssetOwnership): Promise<UserAssetOwnership> {
    var createdUserAssetsOwnership = new UserAssetOwnership();

    await this.http.post<UserAssetOwnership>(`${environment.apiUrl}/UserAssetOwnership/Aquire`, userAsset)
      .pipe(map(result => {
        createdUserAssetsOwnership = result;
      })).toPromise();

    return await createdUserAssetsOwnership;
  }
}