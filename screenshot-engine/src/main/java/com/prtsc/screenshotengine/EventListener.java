package com.prtsc.screenshotengine;

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


    EventReceiver eventReceiver;

    @Autowired
    public EventListener(EventReceiver eventReceiver) {
        this.eventReceiver = eventReceiver;
    }

    @RabbitListener(queues = HELLO)
    public void receiveHelloMessage(String message) {
        log.info("HelloMessage Received: " + message);
    }

    @RabbitListener(queues = TAKE_SCRENSHOT)
    public void receiveTakeScreenshotMessage(String message) {
        log.info("TakeScreenshotMessage Received: " + message);
        eventReceiver.receiveMessage(message);
    }
}
