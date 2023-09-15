export interface AttemptInfo {
  /**
   * Количество оставшихся попыток.
   */
  leftAttemptsNumber: number;

  /**
   * Отметка о том, что достигнуто максимальное количество попыток.
   */

  isAttemptsMaxNumber: boolean;

  /**
   * Отметка о том, что попытка была успешной.
   */
  isSuccess: boolean;
}
