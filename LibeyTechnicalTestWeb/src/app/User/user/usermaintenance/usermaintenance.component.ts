import Swal from 'sweetalert2';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { LibeyUserService } from '../../../core/service/libeyuser/libeyuser.service'
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, Subject, of, takeUntil } from 'rxjs';

export type verbHttp = 'POST' | 'PUT'

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit,OnDestroy {
  form:FormGroup = form()
  tipoDocumentos$:Observable<any> = of([{ id:1,descripcion:"DNI"},{id:2,descripcion:"RUC"}])
  departamentos$:Observable<any> = of([ {id:1,descripcion:"LIMA" },{id:2,descripcion:"CALLAO" }])
  provincias$:Observable<any> = of([ {id:1,descripcion:"LIMA" },{id:2,descripcion:"CALLAO" }])
  distritos$:Observable<any> = of([ {id:"1",descripcion:"LIMA" },{id:"2",descripcion:"CALLAO" }])
  verbHttp:verbHttp = 'POST'
  private unsubscribes$:Subject<void> = new Subject<void>()
  constructor(private libeyUserService:LibeyUserService) { }

  ngOnInit(): void {
    this.libeyUserService.user$
    .pipe(takeUntil(this.unsubscribes$))
    .subscribe((response:any)=>{
        if(response) {
          response['active'] = String(response['active'])
          response['ubigeoCode'] = response['ubigeoCode'] ?? ""
          this.form.patchValue(response)
          this.verbHttp = 'PUT'
        }
    })
  }
  Submit(){
    const form = {data:this.form.value,verbHttp:this.verbHttp} 
    this.libeyUserService.User(form).subscribe((response:any)=>{
        Swal.fire("Se actualizo");
    })
    
  }

  ngOnDestroy(): void {
    this.unsubscribes$.next()
    this.unsubscribes$.complete()
  }
}

export const form = ()=>{
  return new FormGroup({
    documentNumber:new FormControl(""),
    documentTypeId:new FormControl(0),
    name:new FormControl(""),
    fathersLastName:new FormControl(""),
    mothersLastName:new FormControl(""),
    address:new FormControl(""),
    ubigeoCode:new FormControl(""),
    phone:new FormControl(""),
    email:new FormControl(""),
    password:new FormControl(""),
    active:new FormControl("true")
  })
}