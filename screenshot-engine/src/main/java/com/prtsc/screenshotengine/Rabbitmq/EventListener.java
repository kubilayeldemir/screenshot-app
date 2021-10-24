package com.prtsc.screenshotengine.Rabbitmq;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class EventListener {
    static final String TAKE_SCRENSHOT = "take-screenshot";
    static final String HELLO = "hello";

    Logger log = LoggerFactory.getLogger(EventListener.class);
    ScreenshotRequestEvent screenshotRequestEvent;

    @Autowired
    public EventListener(ScreenshotRequestEvent screenshotRequestEvent) {
        this.screenshotRequestEvent = screenshotRequestEvent;
    }

    @RabbitListener(queues = HELLO)
    public void receiveHelloMessage(String message) {
        log.info("HelloMessage Received: " + message);
    }

    @RabbitListener(queues = TAKE_SCRENSHOT)
    public void receiveTakeScreenshotMessage(String message) {
        log.info("TakeScreenshotMessage Received: " + message);
        screenshotRequestEvent.processScreenshotRequestMessage(message);
    }
}
