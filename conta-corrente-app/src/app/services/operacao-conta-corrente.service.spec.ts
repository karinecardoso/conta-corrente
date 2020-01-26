import { TestBed } from "@angular/core/testing";

import { OperacaoContaCorrenteService } from "./operacao-conta-corrente.service";
import { HttpClientModule } from "@angular/common/http";

describe("OperacaoContaCorrenteService", () => {
  beforeEach(() =>
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    })
  );

  it("should be created", () => {
    const service: OperacaoContaCorrenteService = TestBed.get(
      OperacaoContaCorrenteService
    );
    expect(service).toBeTruthy();
  });
});
