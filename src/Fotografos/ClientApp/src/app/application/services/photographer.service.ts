import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { Photographer } from "src/app/model/Photographer";

@Injectable({
  providedIn: "root",
})
export class PhotographerService {
  constructor(
    private httpClient: HttpClient,
    private messageService: MessageService
  ) {}

  private photographersUrl = "rest/photographer";

  private httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  getPhotographers(): Observable<Photographer[]> {
    return this.httpClient
      .get<Photographer[]>(this.photographersUrl)
      .pipe(catchError(this.handleError<Photographer[]>("Get Photographers")));
  }

  getPhotographer(id: number): Observable<Photographer> {
    const url = `${this.photographersUrl}/${id}`;

    return this.httpClient
      .get<Photographer>(url)
      .pipe(
        catchError(this.handleError<Photographer>("Get Photographer details"))
      );
  }

  createPhotographer(photographer: Photographer): Observable<Photographer> {
    return this.httpClient
      .post<Photographer>(this.photographersUrl, photographer, this.httpOptions)
      .pipe(
        tap((s) =>
          this.messageSuccess(
            `The photographer '${s.name} ${s.surename}' was created successfully`,
            "Create Photographer"
          )
        ),
        catchError(this.handleError<Photographer>("Create Photographer"))
      );
  }

  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      this.messageService.add({
        severity: "error",
        summary: operation,
        detail: "The operation failed",
      });

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private messageSuccess(message: string, operation = "operation") {
    this.messageService.add({
      severity: "success",
      summary: operation,
      detail: message,
    });
  }
}
