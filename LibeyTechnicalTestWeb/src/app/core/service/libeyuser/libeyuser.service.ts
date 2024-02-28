import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";

@Injectable({
	providedIn: "root",
})
export class LibeyUserService {

	constructor(private http: HttpClient) {}

	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	AllUser():Observable<LibeyUser[]>{
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/`;
		return this.http.get<LibeyUser[]>(uri);
	}

	postUser(libeyUser:LibeyUser){
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/`;
		return this.http.post(uri,libeyUser)
	}

	putUser(libeyUser:LibeyUser){
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${libeyUser.documentNumber}`;
		return this.http.put(uri,libeyUser)
	}

	deleteUser(documentNumber:string){
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.delete(uri)
	}


	User({data,verbHttp}:any):Observable<any>{
		const API:any = {
			POST:()=>this.postUser(data),
			PUT:()=>this.putUser(data)
		}
		return API[verbHttp]()
	}


	private user$$:BehaviorSubject<LibeyUser> = new BehaviorSubject<LibeyUser | any>(null)

	set user(libeyUser:LibeyUser){
		this.user$$.next(libeyUser)
	}

	get user$(){
		return this.user$$.asObservable()
	}



}