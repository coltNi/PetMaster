import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { PetByMasterGender } from './model/pet-by-master-gender';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';


@Injectable()
export class PetMasterService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    private serviceUrl = 'api/PetMaster/'; 

    getPetByTypeGroupByMasterGender(type: string): Observable<PetByMasterGender[]> {
        let url: string = `${this.baseUrl}/${this.serviceUrl}/${type}/master-gender-group`;
        return this.http.get(url)
            .map((response: Response) => <PetByMasterGender[]>response.json());
    }
}