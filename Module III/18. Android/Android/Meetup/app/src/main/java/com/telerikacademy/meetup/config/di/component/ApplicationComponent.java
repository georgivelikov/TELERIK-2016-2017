package com.telerikacademy.meetup.config.di.component;

import com.telerikacademy.meetup.config.di.annotation.ApplicationScope;
import com.telerikacademy.meetup.config.di.module.ApplicationModule;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.config.di.module.ServiceModule;
import dagger.Component;

@ApplicationScope
@Component(modules = {ApplicationModule.class})
public interface ApplicationComponent {

    ControllerComponent getControllerComponent(ControllerModule module);

    ServiceComponent getServiceComponent(ServiceModule module);
}
