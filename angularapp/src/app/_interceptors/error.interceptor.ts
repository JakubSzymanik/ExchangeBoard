import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error : HttpErrorResponse) => {
        if (error)
        {
          switch (error.status) {
            case 400:
              //validation error: odczytać tablice errorów
              break;
            case 500:
              //dopisać obsługę reszty kodów
              //jest router żeby móc przekierować użytkownika na odpowiednią stronę
              break;
          }
        }
        throw error;
      })
    );
  }
}
