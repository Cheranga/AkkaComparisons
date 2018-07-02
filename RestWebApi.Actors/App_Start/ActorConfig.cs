﻿using Akka.Actor;
using Akka.Routing;
using Api.Search;
using Autofac;
using Autofac.Core;
using RestWebApi.Actors.Actors;

namespace RestWebApi.Actors
{
    public static class ActorConfig
    {
        public static void Initialise()
        {
            PlateActorSystem.Initialise();
        }
    }

    public static class PlateActorSystem
    {
        public static ActorSystem ActorSystem;
        public static IActorRef SearchActor;

        public static void Initialise()
        {
            ActorSystem = Akka.Actor.ActorSystem.Create("PlateActorSystem");

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<LocalPlateRepository>().As<IPlateRepository>().SingleInstance();
            containerBuilder.RegisterType<SearchActor>().SingleInstance();
            


            var props = Props.Create(() => new SearchActor()).WithRouter(FromConfig.Instance);

            SearchActor = ActorSystem.ActorOf(props, "SearchActor");
        }

    }
}