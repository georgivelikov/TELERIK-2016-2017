package com.telerikacademy.meetup.config.di.component;

import com.telerikacademy.meetup.config.di.annotation.ServiceScope;
import com.telerikacademy.meetup.config.di.module.ServiceModule;
import dagger.Subcomponent;

@ServiceScope
@Subcomponent(modules = {ServiceModule.class})
public interface ServiceComponent {
}
