import { RoleTypeEnum } from "../../enums/role-type";

/** Роль пользователь */
export interface UserIdentityModel {
  /** роль */
  roleType: RoleTypeEnum
  roleName: string;
}
