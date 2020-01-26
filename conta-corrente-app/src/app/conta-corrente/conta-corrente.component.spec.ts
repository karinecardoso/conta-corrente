import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ContaCorrenteComponent } from "./conta-corrente.component";
import { ReactiveFormsModule } from "@angular/forms";
import { NgxCurrencyModule } from "ngx-currency";
import { ToastrModule } from "ngx-toastr";
import { HttpClientModule } from "@angular/common/http";

describe("ContaCorrenteComponent", () => {
  let component: ContaCorrenteComponent;
  let fixture: ComponentFixture<ContaCorrenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        ReactiveFormsModule,
        NgxCurrencyModule,
        ToastrModule.forRoot()
      ],
      declarations: [ContaCorrenteComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaCorrenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
