import { Component, OnDestroy, OnInit } from '@angular/core';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { LibeyUser } from '../../../entities/libeyuser';
import { Observable, Subject, takeUntil } from 'rxjs';
import { Router } from '@angular/router'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit,OnDestroy {

  users2 = [
    { nombre: 'Usuario 1', email: 'usuario1@example.com', edad: 30 },
    { nombre: 'Usuario 2', email: 'usuario2@example.com', edad: 25 },
    { nombre: 'Usuario 3', email: 'usuario3@example.com', edad: 40 },
  ];
  users: LibeyUser[] = [];
  users$!:Observable<LibeyUser[]>
  private unsubscribes$:Subject<void> = new Subject<void>()
  constructor(private libeyUserService: LibeyUserService,private router:Router) { }


  ngOnInit(): void {
    this.users$ = this.libeyUserService.AllUser()
  }

  editarUsuario({ documentNumber }: LibeyUser) {
    this.libeyUserService.Find(documentNumber)
    .pipe(takeUntil(this.unsubscribes$))
    .subscribe((libeyUser:LibeyUser)=>{
      this.libeyUserService.user =  libeyUser
      this.router.navigate(['user/maintenance'])
    })
    
  }

  eliminarUsuario({ documentNumber }: LibeyUser) {
    this.libeyUserService.deleteUser(documentNumber).subscribe((response)=>{
      Swal.fire("Se Elimino");
    })
  }

  ngOnDestroy(): void {
    this.unsubscribes$.next();
    this.unsubscribes$.complete()
  }


}
