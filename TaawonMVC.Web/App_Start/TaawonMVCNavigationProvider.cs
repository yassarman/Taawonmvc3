using Abp.Application.Navigation;
using Abp.Localization;
using TaawonMVC.Authorization;

namespace TaawonMVC.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class TaawonMVCNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Application,
                        L("Application"),
                        url: "Applications",
                        icon: "add_box"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.ApprovedApplication,
                        L("ApprovedApplications"),
                        url: "Applications/ApprovedApplicationView",
                        icon: "add_box"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.RejectedApplication,
                        L("RejectedApplications"),
                        url: "Applications/RejectedApplicationsView",
                        icon: "add_box"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Projects,
                        L("Projects"),
                        url: "Applications/ProjectsView",
                        icon: "add_box"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Reports,
                        L("Reports"),
                        url: "Reporting/ReportsListView",
                        icon: "view_list"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "LookUp",
                        L("LookUp"),
                        icon: "menu"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.BuildingsType,
                            L("BuildingType"),
                            url: "BuildingType/BuildingType",
                            icon: "add_box"
                                               )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Neighborhood,
                            L("Neighborhood"),
                            url: "Neighborhood/Index",
                            icon: "add_box"
                                               )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Building,
                            L("Building"),
                            url: "Building/Index",
                            icon: "add_box"
                                               )
                ).AddItem(
                        new MenuItemDefinition(
                            PageNames.BuildingUses,
                            L("BuildingUses"),
                            url: "BuildingUses/BuildingUses",
                            icon: "add_box"
                                  )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.BuildingUnit,
                                L("BuildingUnit"),
                                url: "BuildingUnit/BuildingUnit",
                                icon: "add_box"
                            )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                PageNames.BuildingUnitContent,
                                L("BuildingUnitContents"),
                                url: "BuildingUnitContents/BuildingUnitContents",
                                icon: "add_box"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.InterventionType,
                                L("InterventionType"),
                                url: "InterventionType",
                                icon: "add_box"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.RestorationType,
                                L("RestorationType"),
                                url: "RestorationType",
                                icon: "add_box"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.PropertyOwnership,
                                L("PropertyOwnership"),
                                url: "PropertyOwnership",
                                icon: "add_box"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Donors,
                                L("Donors"),
                                url: "Donors",
                                icon: "add_box"
                            )
                        )

                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaawonMVCConsts.LocalizationSourceName);
        }
    }
}
