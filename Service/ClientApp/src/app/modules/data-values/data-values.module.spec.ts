import { DataValuesModule } from './data-values.module';

describe('DataValuesModule', () => {
  let dataValuesModule: DataValuesModule;

  beforeEach(() => {
    dataValuesModule = new DataValuesModule();
  });

  it('should create an instance', () => {
    expect(dataValuesModule).toBeTruthy();
  });
});
