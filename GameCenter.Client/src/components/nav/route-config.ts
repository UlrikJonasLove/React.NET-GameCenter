import { CreateGenre } from "../genres/CreateGenre";
import { EditGenre } from "../genres/EditGenre";
import { Genres } from "../genres/Genres";

import { Actors } from "../actors/Actors";
import { CreateActor } from "../actors/CreateActor";
import { EditActor } from "../actors/EditActor";

import { GameCenters } from "../gamecenters/GameCenters";
import { CreateGameCenter } from "../gamecenters/CreateGameCenter";
import { EditGameCenter } from "../gamecenters/EditGameCenter";

import { LandingPage } from "../games/LandingPage";
import { FilterGame } from "../games/FilterGame";
import { CreateGame } from "../games/CreateGame";
import { EditGame } from "../games/EditGame";
import { RedirectToLandingPage } from "../Utils/RedirectToLandingPage";

export const routes = [
    {path: "/genres", component: Genres, exact: true},
    {path: "/genres/create", component: CreateGenre},
    {path: "/genres/edit/:id(\\d+)", component: EditGenre},

    {path: "/actors", component: Actors, exact: true},
    {path: "/actors/create", component: CreateActor},
    {path: "/actors/edit:id(\\d+)", component: EditActor},

    {path: "/gamecenters", component: GameCenters, exact: true},
    {path: "/gamecenters/create", component: CreateGameCenter},
    {path: "/gamecenters/edit:id(\\d+)", component: EditGameCenter},

    {path: "/games/filter", component: FilterGame},
    {path: "/games/create", component: CreateGame},
    {path: "/games/edit:id(\\d+)", component: EditGame},


    {path: "/", component: LandingPage, exact: true},
    {path: "*", component: RedirectToLandingPage}
];