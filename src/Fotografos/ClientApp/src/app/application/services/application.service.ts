import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { Application } from "src/app/model/Application";

@Injectable({
  providedIn: "root",
})
export class ApplicationService {
  constructor(
    private httpClient: HttpClient,
    private messageService: MessageService
  ) {}

  private applicationsUrl = "rest/application";

  private httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  getApplications(): Observable<Application[]> {
    return this.httpClient
      .get<Application[]>(this.applicationsUrl)
      .pipe(catchError(this.handleError<Application[]>("Get Applications")));
  }

  getApplication(id: number): Observable<Application> {
    const url = `${this.applicationsUrl}/${id}`;

    return this.httpClient
      .get<Application>(url)
      .pipe(
        catchError(this.handleError<Application>("Get Application details"))
      );
  }

  createApplication(application: Application): Observable<Application> {
    return this.httpClient
      .post<Application>(this.applicationsUrl, application, this.httpOptions)
      .pipe(
        tap((s) =>
          this.messageSuccess(
            `The application '${s.name}' was created successfully`,
            "Create Application"
          )
        ),
        catchError(this.handleError<Application>("Create Application"))
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
